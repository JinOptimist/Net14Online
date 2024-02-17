namespace Net14Web.Services
{
    public class UploadFileHelper
    {
        public async Task<bool> UploadFile(string filePath, IFormFile file)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return true;
        }
    }
}
