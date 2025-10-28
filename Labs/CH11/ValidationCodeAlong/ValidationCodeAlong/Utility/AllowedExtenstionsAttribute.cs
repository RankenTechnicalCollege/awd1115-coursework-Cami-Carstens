using System.ComponentModel.DataAnnotations;

namespace ValidationCodeAlong.Utility
{
    public class AllowedExtenstionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AllowedExtenstionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        public override bool IsValid(object? value)
        {
            if(value is not Microsoft.AspNetCore.Http.IFormFile file)
            {
                return false;
            }
            string extension = System.IO.Path.GetExtension(file.FileName);
            return _extensions.Contains(extension.ToLower());
        }
    }
}
