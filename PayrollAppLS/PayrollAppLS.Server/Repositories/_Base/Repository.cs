using System;
using LightSwitchApplication;
using PayrollApp.Domain.Exceptions;

namespace PayrollApp.Infrastructure.Repositories
{
    public class Repository: IDisposable
    {
        private DataWorkspace _dataWorkspace;

        protected DataWorkspace DataWorkspace
        {
            get
            {
                if (_dataWorkspace == null)
                    _dataWorkspace = Application.Current.CreateDataWorkspace();
                return _dataWorkspace;
            }
        }

        protected void CheckNotNull<T>(T dbEntity)
        {
            if(dbEntity == null)
                throw new AggregateNotExistsException();
        }

        public void Save()
        {
            try
            {
                DataWorkspace.ApplicationData.SaveChanges();
            }
            catch (Exception ex)
            {
                DataWorkspace.ApplicationData.Details.DiscardChanges();
                throw ex;
            }
        }

        public void Dispose()
        {
            if(_dataWorkspace != null)
                _dataWorkspace.Dispose();
        }
    }
}