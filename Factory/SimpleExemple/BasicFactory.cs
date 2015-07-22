// ist : https://gist.github.com/oinant/4ca495386bec0fa96f22
using System;

namespace Oinant.Blog.Factory.SimpleExemple
{
    public class MyBusinessObject
    {
        private string _content;
        private DateTime _dateTimeReleventToBusinessLogic;
        public MyBusinessObject(Tuple<DateTime, String> creationData)
        {
            _content = creationData.Item2;
            _dateTimeReleventToBusinessLogic = creationData.Item1;
        }

        public bool IsBusinessRequirementMet()
        {
            return !string.IsNullOrEmpty(_content);
        }

        public void PerformBusinessLogic()
        {
            
        }

        public string GetContent()
        {
            return _content;
        }
    }

    class MyBusinessObjectFactory
    {
        private readonly IBusinessRepository _businessRepository;

        public MyBusinessObjectFactory(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

        public MyBusinessObject Create(Guid id)
        {
            var content = _businessRepository.GetContent(id);
            return new MyBusinessObject(new Tuple<DateTime, string>(DateTime.Now, content));
        }
    }

    public class Client
    {
        
        private void Run()
        {
            var factory = new MyBusinessObjectFactory(new DummyBusinessRepository());

            var myRunnerId = new Guid();

            MyBusinessObject myObject = factory.Create(myRunnerId);

            if(myObject.IsBusinessRequirementMet())
                myObject.PerformBusinessLogic();
        }
        
    }

    public interface IBusinessRepository
    {
        string GetContent(Guid id);
    }

    public class DummyBusinessRepository : IBusinessRepository
    {
        public string GetContent(Guid id)
        {
            return id.ToString();
        }
    }
}
