namespace Assets._Project.Develop.Runtime.Utilities.DataManagment.KeyStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }

}
