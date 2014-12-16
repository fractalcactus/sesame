using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using ggak_final_project.Controllers;
using ggak_final_project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ggak_final_project.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //create test method
        //create new controler instance
        //create a new fake iworldplaygroind make a new class that implments iworldthingy
        private IWorldPlaygroundDBContext _context;
        private WayPointsController _controller;

        [ClassInitialize]
        public void SetUp()
        {
           _context  = new fakeDataContext();
            WayPoint w1 = new WayPoint();
            w1.Id = 1;
            w1.Latitude = (float) 41.234343;
            w1.Longitude = (float) 43.234343;
            w1.URL = "W1URL";
            _context.WayPoints.Add(w1);
            WayPoint w2 = new WayPoint();
            w1.Id = 2;
            w1.Latitude = (float) 44.234343;
            w1.Longitude = (float) 45.234343;
            w1.URL = "W2URL";
            WayPoint w3 = new WayPoint();
            w1.Id = 3;
            w1.Latitude = (float) 49.234343;
            w1.Longitude = (float) 48.234343;
            w1.URL = "W3URL";

            _controller = new WayPointsController(_context);

        }

    

        [TestMethod]
        public void is_in_radius_with_exact_coords()
        {
            //act
        WayPoint checkWayPoint =  _controller.GetWayPoint("41.234343", "43.234343");
            Assert.AreEqual("W1URL",checkWayPoint.URL);

        }
    }

    public class fakeDataContext : IWorldPlaygroundDBContext
    {

        public System.Data.Entity.IDbSet<WayPoint> WayPoints { get;  set; }
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        public int SaveChanges()
        {
            return 0;

        }

        public void Dispose()
        {

        }
    }


    public class FakeDbSet<T> : IDbSet<T> where T :WayPoint
    {
        private ObservableCollection<T> _data;
        private IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        //public TDerivedEntity Create<WayPoint>() where TDerivedEntity :  WayPoint
        //{
        //    return Activator.CreateInstance<TDerivedEntity>();
        //}

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _query.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }




        T IDbSet<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Attach(T entity)
        {
            throw new NotImplementedException();
        }

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Create()
        {
            throw new NotImplementedException();
        }

        T IDbSet<T>.Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<T> IDbSet<T>.Local
        {
            get { throw new NotImplementedException(); }
        }

        T IDbSet<T>.Remove(T entity)
        {
            throw new NotImplementedException();
        }

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        Type IQueryable.ElementType
        {
            get { throw new NotImplementedException(); }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { throw new NotImplementedException(); }
        }

        IQueryProvider IQueryable.Provider
        {
            get { throw new NotImplementedException(); }
        }
    }

}
