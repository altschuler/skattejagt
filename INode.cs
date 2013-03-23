namespace Skattejagt
{
    public interface INode
    {
	INode Parent { get; set; }
	Action Action { get; set; }
	State State { get; set; }
	double PathCost { get; set; }
	double EstimatedTotalPathCost { get; set; }
    }
}