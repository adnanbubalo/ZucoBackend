namespace ZucoBackend.Services
{
    public class ImageService
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment hostEnvironment;

        public ImageService(AppDbContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<string> uploadImage(IFormFile image)
        {
            ImageModel imageModel = new ImageModel();
            var fileType = Path.GetExtension(image.FileName);
            var docName = Path.GetFileName(image.FileName);
            try
            {
                if (fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
                {
                    var filePath = hostEnvironment.WebRootPath;

                    imageModel.Name = docName;
                    imageModel.DocType = fileType;
                    imageModel.DocUrl = Path.Combine(filePath, "images", docName);

                    using (var stream = new FileStream(imageModel.DocUrl, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            return "/images/" + docName;
        }
    }
}
