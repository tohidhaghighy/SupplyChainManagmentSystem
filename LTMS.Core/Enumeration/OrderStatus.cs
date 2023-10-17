namespace Schm.Core.Enumeration
{
    public enum OrderStatus
    {
        Payed = 1,
        Error_In_Payment,
        Accept_By_Supplier,
        Reject_By_Supplier,
        In_Progress,
        Ready_To_Send,
        Sended,
        Rejected_By_User,
    }
}
