using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.DndApiHelper;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;

namespace Net14Web.Services
{
    public class ReflectionService
    {
        public ApiHelperViewModel BuildApiHelperViewModel(Type apiControllerType)
        {
            var controllerMethodsNames = typeof(Controller)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name)
                .ToList();

            var apiHelperViewModel = new ApiHelperViewModel();
            apiHelperViewModel.Name = apiControllerType.Name;
            apiHelperViewModel.Methods = apiControllerType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => !controllerMethodsNames.Contains(method.Name))
                .Select(method => new MethodViewModel()
                {
                    Name = method.Name,
                    MethodType = CalculateMethodTypeByAttributes(method),
                    Parameters = method
                        .GetParameters()
                        .Select(parameter => new ParameterViewModel()
                        {
                            Name = parameter.Name,
                            TypeName = parameter.ParameterType.Name,
                            Exmaple = GetDefaultValue(parameter.ParameterType)
                        })
                        .ToList()
                })
                .ToList();

            return apiHelperViewModel;
        }

        private string GenerateJsonExample(Type parameterType, int deep)
        {
            var listGenericType = parameterType
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (listGenericType != null)
            {
                // parameterType == IEnumerable<T>
                var listType = listGenericType.GetGenericArguments()[0];
                // listType == T

                return $"[{GetDefaultValue(listType, deep + 1)}]";
            }

            var sb = new StringBuilder();
            var properties = parameterType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            sb.AppendLine("{");

            var spaces = new string(' ', deep * 2);
            foreach (var property in properties)
            {
                sb.AppendLine($"{spaces}{property.Name}: {GetDefaultValue(property.PropertyType, deep + 1)},");
            }

            var endSpaces = new string(' ', (deep - 1) * 2);
            sb.Append($"{endSpaces}}}");

            return sb.ToString();
        }

        private string GetDefaultValue(Type propertyType, int deep = 1)
        {
            if (propertyType == typeof(string))
            {
                return "'text'";
            }

            if (propertyType.IsValueType)
            {
                if (propertyType.IsGenericType
                    && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Nullable<T>
                    var realValueType = propertyType.GetGenericArguments()[0];
                    // T
                    return Activator.CreateInstance(realValueType).ToString();
                }

                return Activator.CreateInstance(propertyType).ToString();
            }

            return GenerateJsonExample(propertyType, deep);
        }

        private MethodType CalculateMethodTypeByAttributes(MethodInfo methodInfo)
        {
            var attributes = methodInfo.GetCustomAttributes();
            if (attributes.Any(x => x is HttpPostAttribute))
            {
                return MethodType.Post;
            }

            if (attributes.Any(x => x is HttpGetAttribute))
            {
                return MethodType.Get;
            }

            return MethodType.None;
        }
    }
}
