namespace BenchmarkInvestigations.Core.SupportingTypes;

public sealed class Root
{
	public Root() => this.Children = new List<ChildOfRoot>();

	public List<ChildOfRoot> Children { get; }
}

public sealed class ChildOfRoot
{
	public ChildOfRoot() => this.Children = new List<ChildOfChildOfRoot>();

	public List<ChildOfChildOfRoot> Children { get; }
}

public sealed class ChildOfChildOfRoot
{
	public ChildOfChildOfRoot(Guid idGuid, State state, bool @switch)
	{
		this.IdGuid = idGuid;
		this.State = state;
		this.Switch = @switch;
	}

	public Guid IdGuid { get; }
	public State State { get; }
	public bool Switch { get; }
}

public enum State { Value1, Value2, Value3 }