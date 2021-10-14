namespace eWolfMetaImage.Helpers
{
    public interface ISaveable
    {
        string GetFileName { get; }

        bool Modifyed { get; set; }
    }
}