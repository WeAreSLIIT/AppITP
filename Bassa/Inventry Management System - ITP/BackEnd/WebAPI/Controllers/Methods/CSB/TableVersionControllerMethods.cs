using DataAccess.Core;
using DataAccess.Core.Domain;
using System.Collections.Generic;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class TableVersionControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public TableVersionControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public TableVersionResource TableVersionResourceToTableVersion(TableVersion TableVersion)
        {
            if (TableVersion == null)
                return null;

            return new TableVersionResource()
            {
                ID = TableVersion.TableID,
                Version = TableVersion.Time
            };
        }

        public ICollection<TableVersionResource> ListTableVersionResourceToListTableVersion(ICollection<TableVersion> TableVersions)
        {
            if (TableVersions == null || TableVersions.Count == 0)
                return null;

            ICollection<TableVersionResource> TableVersionResources = new List<TableVersionResource>();
            
            foreach (TableVersion TableVersion in TableVersions)
            {
                TableVersionResources.Add(this.TableVersionResourceToTableVersion(TableVersion));
            }

            return TableVersionResources;
        }
    }
}