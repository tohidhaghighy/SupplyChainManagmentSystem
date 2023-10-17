namespace Schm.UI.Infrastructure.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        // type = Enter , Exit
        public string DocumentType { get; set; }
        public string DocumentCode { get; set; }
        public string InsertDate { get; set; }
        public bool IsDeleted { get; set; }
        public string InsertedUsername { get; set; }
        public bool IsFinal { get; set; }
        public string IsFinalStr {
            get {
                if (IsFinal)
                {
                    return "نهایی شده";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
