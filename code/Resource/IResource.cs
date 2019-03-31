
// I added this becase when a "where constraint"
// needs to be of ResourceBase type, You can't use ResourceBase<T> because it is generic
// Instead uses this interface
public interface IResource
{
}
