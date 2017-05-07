using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Presenting.Models;

namespace DataAccess.Presenting
{
    public class MainViewModel
    {
        private readonly IDataContext _context;

        public ObservableCollection<DummyModel1> DummyModel1s { get; set; }
        public ObservableCollection<DummyModel2> DummyModel2s { get; set; }

        public MainViewModel(IDataContext context)
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<DummyEntity1, DummyModel1>();
                c.CreateMap<DummyEntity2, DummyModel2>();
            });

            _context = context;

            DummyModel1s = new ObservableCollection<DummyModel1>(Mapper.Map<IList<DummyModel1>>(_context.GetAllDummyEntity1s()));
            DummyModel2s = new ObservableCollection<DummyModel2>(Mapper.Map<IList<DummyModel2>>(_context.GetAllDummyEntity2s()));

        }
    }
}
