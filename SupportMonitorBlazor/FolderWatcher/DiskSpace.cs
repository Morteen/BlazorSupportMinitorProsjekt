namespace FolderWatcher
{
   public class DiskSpace
    {
        public int Id{ get; set; }
        public int TmsId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
       public int FreespacePercentMinimum { get; set; }
       public int FrespaceMinimumBytes { get; set; }
     public int Actualsize { get; set; }
       public int MaxSize { get; set; }

    }
}
    
