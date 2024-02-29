namespace GetechnologiesMx.Application.Models {
    public record InvoiceModel(
        DateTime Date = default,
        decimal Amount = default
    );
}
