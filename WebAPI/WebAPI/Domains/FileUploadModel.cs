using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Domains
{
    public class FileUploadModel
    {
        
        public IFormFile? Image { get; set; }
    }
}
