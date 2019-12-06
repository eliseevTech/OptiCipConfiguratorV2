namespace OpcConfigurationCreator
{
    public interface IOpcTag
    {
        string TagName { get; set; }
        string Address { get; set; }
        string DataType { get; set; }
        string RespectDataType { get; set; }
        string ClientAccess { get; set; }
        string ScanRate { get; set; }
        string Scaling { get; set; }
        string RawLow { get; set; }
        string RawHigh { get; set; }
        string ScaledLow { get; set; }
        string ScaledHigh { get; set; }
        string ScaledDataType { get; set; }
        string ClampLow { get; set; }
        string ClampHigh { get; set; }
        string EngUnits { get; set; }
        string Description { get; set; }
        string NegateValue { get; set; }

        string ToString();
    }
}
