using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Application.ViewModel;
using TruckManager.Domain.Entity;

namespace TruckManager.Application.Interfaces
{
    public interface IAppBase<TEntidade, TViewModel>
            where TEntidade : EntityBase
            where TViewModel : ViewModelBase
    {
        int Add(TViewModel viewModel);
        void Delete(int id);
        void Delete(TViewModel viewModel);
        void Update(TViewModel viewModel);
        TViewModel Find(int id);
        IEnumerable<TViewModel> All();
    }
}
