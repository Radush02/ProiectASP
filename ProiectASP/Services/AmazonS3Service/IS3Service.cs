namespace ProiectASP.Services.AmazonS3Service
{
    public interface IS3Service
    {
        Task UploadFileAsync(string key, Stream fileStream);

    }
}
