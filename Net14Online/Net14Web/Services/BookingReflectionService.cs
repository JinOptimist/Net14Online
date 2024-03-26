using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.BookingHelper;
using System.Reflection;

namespace Net14Web.Services
{
    public class BookingReflectionService
    {
        public BookingHelperViewModel BuildBookingHelperViewModel(Type controllerType)
        {
            var controllerMethodsNames = typeof(Controller)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => x.Name)
                .ToList();

            var bookingHelperViewModel = new BookingHelperViewModel();
            bookingHelperViewModel.Name = controllerType.Name;
            bookingHelperViewModel.Methods = controllerType
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(method => !controllerMethodsNames.Contains(method.Name))
                .Select(method => new Models.BookingHelper.MethodViewModel()
                {
                    Name = method.Name,
                    MethodType = CalculateMethodTypeByAttributes(method),
                    Parameters = method
                        .GetParameters()
                        .Select(parameter => new ParameterViewModel()
                        {
                            Name = parameter.Name,
                            TypeName = parameter.ParameterType.Name
                        })
                        .ToList()
                })
                .ToList();

            return bookingHelperViewModel;
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