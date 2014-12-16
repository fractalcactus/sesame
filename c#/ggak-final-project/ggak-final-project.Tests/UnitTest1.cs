using System;
using System.Collections.Generic;
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
        private float radiusThreshold = (float)0.001;

       [TestInitialize]
        public void SetUp()
        {
             _context  = new fakeDataContext();
           
            WayPoint w1 = new WayPoint();
            w1.Id = 1;
            w1.Latitude = (float) 41.234343;
            w1.Longitude = (float) 43.234343;
            w1.URL = "W1URL";
          
            WayPoint w2 = new WayPoint();
            w2.Id = 2;
            w2.Latitude = (float) 44.234343;
            w2.Longitude = (float) 45.234343;
            w2.URL = "W2URL";

            WayPoint w3 = new WayPoint();
            w3.Id = 3;
            w3.Latitude = (float) 49.234343;
            w3.Longitude = (float) 48.234343;
            w3.URL = "W3URL";


            _context.WayPoints.Add(w1);
            _context.WayPoints.Add(w2);
            _context.WayPoints.Add(w3);
            _controller = new WayPointsController(_context);

        }

    

        [TestMethod]
        public void is_in_radius_with_exact_coords()
        {
            //arrange
           // SetUp();
            //act
        WayPoint checkWayPoint =  _controller.GetWayPoint("41.234343", "43.234343");
            //assert
            Assert.AreEqual("W1URL",checkWayPoint.URL);

        }

    

        [TestMethod]
        public void isnt_in_radius_with_wrong_coords()
        {

            //act
            WayPoint checkWayPoint = _controller.GetWayPoint("1.234343", "43.234343");
            //assert
            Assert.IsNull(checkWayPoint.URL);

        }

        [TestMethod]
        public void is_in_radius_with_only_long_off_by_one()
        {

            //act
            WayPoint checkWayPoint = _controller.GetWayPoint("41.233343", "43.234343"); //41.234343 - 0.001
            //assert
            Assert.AreEqual("W1URL", checkWayPoint.URL);

        }

        //[TestMethod]
        //public void is_in_radius_with_only_lat_off_by_one()
        //{

        //    //act
        //    WayPoint checkWayPoint = _controller.GetWayPoint("41.233343", "43.233343"); //43.234343 - 0.001
        //    //assert
        //    Assert.AreEqual("W1URL", checkWayPoint.URL);

        //}

        [TestMethod]
        public void isnt_in_radius_with_long_off_by_two()
        {

            //act
            WayPoint checkWayPoint = _controller.GetWayPoint("41.233343", "43.231343"); //43.234343 - 0.002
            //assert
            Assert.IsNull(checkWayPoint.URL);

        }

        [TestMethod]
        public void isnt_in_radius_with_long_and_lat_off_by_one()
        {

            //act
            WayPoint checkWayPoint = _controller.GetWayPoint("41.233343", "43.233343"); //- 0.001
            //assert
            Assert.IsNull(checkWayPoint.URL);

        }

        [TestMethod]
        public void isnt_in_radius_with_long_and_lat_off_by_sin45_radius_Threshold()
        {
           float checkLat = (float) (41.233343 - (radiusThreshold * Math.Sin(45 * (Math.PI / 180))));
           float checkLong = (float)(43.233343 - (radiusThreshold * Math.Sin(45 * (Math.PI / 180))));
            //act
            WayPoint checkWayPoint = _controller.GetWayPoint("41.233343", "43.233343"); //- 0.001
            //assert
            Assert.IsNull(checkWayPoint.URL);

        }



























    }

    public class fakeDataContext : IWorldPlaygroundDBContext
    {
        public fakeDataContext()
        {
            this.WayPoints = new FakeDbSet<WayPoint>();
        }

        public IDbSet<WayPoint> WayPoints { get;  set; }
      

        public int SaveChanges()
        {
            return 0;

        }

        public void Dispose()
        {

        }
    }


    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private ObservableCollection<T> _data;
        private IQueryable _query;

        public FakeDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(List<T> fakeCollection )
        {
            _data = new ObservableCollection<T>(fakeCollection);
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
            get { return _data; }
        }

        public T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        //public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        //public Type ElementType
        //{
        //    get { return _query.ElementType; }
        //}

        //public System.Linq.Expressions.Expression Expression
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public System.Linq.IQueryProvider Provider
        //{
        //    get { throw new NotImplementedException(); }
        //}




        //T IDbSet<T>.Add(T item)
        //{
        //    _data.Add(item);
        //    return item;
        //}

        //T IDbSet<T>.Attach(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        TDerivedEntity IDbSet<T>.Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        //T IDbSet<T>.Create()
        //{
        //    throw new NotImplementedException();
        //}

        //T IDbSet<T>.Find(params object[] keyValues)
        //{
        //    throw new NotImplementedException();
        //}

        //ObservableCollection<T> IDbSet<T>.Local
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //T IDbSet<T>.Remove(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        System.Collections.Generic.IEnumerator<T> System.Collections.Generic.IEnumerable<T>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return _query.Provider; }
        }
    }

}
