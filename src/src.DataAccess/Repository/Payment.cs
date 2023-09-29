namespace src.DataAccess;

public class Payment
{
    public long PaymentID { get; set; }
    public long OuterPayID { get; set; }
    public int AgentID { get; set; }
    public int ProviderID { get; set; }
    public string Number { get; set; }
    public DateTime RegDateTime { get; set; }
    public DateTime StatusDateTime { get; set; }
    public string ProviderPaymentID { get; set; } = null!;
    public string ReceiptID { get; set; } = null!;
    public decimal PaySum { get; set; }
    public decimal ProviderSum { get; set; }
    public decimal USD { get; set; }
    public decimal CancelSum { get; set; }
    public int Status { get; set; }
    public int ErrorCode { get; set; }
    public string ProviderErrorCode { get; set; } = null!;
    public int Terminal { get; set; }
    public int Theadpool { get; set; }
    public decimal EmonCommis { get; set; }
    public bool IsComplate { get; set; }
    public decimal treg { get; set; }
    public decimal FeeSum { get; set; }
    public string TerminalType { get; set; } = null!;
    public int ReceiptNum { get; set; }
    public int ReceiptPrint { get; set; }
    public decimal PaySumma { get; set; }
    public string PayCurr { get; set; } = null!;
    public decimal SendSumma { get; set; }
    public string SendCurr { get; set; } = null!;
    public decimal CurRate { get; set; }
    public string BackUrl { get; set; } = null!;
    public string NotifyEmail { get; set; } = null!;
    public decimal Fee { get; set; }
    public string extras { get; set; } = null!;
    public string ToSend { get; set; } = null!;
}
