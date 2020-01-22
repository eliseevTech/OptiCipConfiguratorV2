using EntityAccessOnFramework.Data;

namespace OptiCipAdministratorHelper2.Services
{
    public class AccessContextService
    {
        public AccessContext Context { get; private set; }
        public string FilePath { get; private set; }
        /// <summary>
        /// Задать новый контекст
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public AccessContext SetContext(string filePath)
        {
            FilePath = filePath;
            Context = new AccessContext(filePath);
            return Context;
        }
    }
}
