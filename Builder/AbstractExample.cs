using System;
using System.Security.Policy;

namespace Builder
{
    public class MyClass
    {
        private readonly string _aStringProperty;
        private readonly bool _aGivenFlag;
        private readonly bool _anotherFlag;

        public MyClass(string aStringProperty, bool aGivenFlag, bool anotherFlag)
        {
            _aStringProperty = aStringProperty;
            _aGivenFlag = aGivenFlag;
            _anotherFlag = anotherFlag;
        }

        public object DoSomeBehavior()
        {
            dynamic @object = null;
            @object.actionAt = DateTime.UtcNow;
            @object.theName = _aStringProperty;

            if (_aGivenFlag)
                @object.theName = "the property : " + @object.theName;

            if (_anotherFlag)
                @object.theName = @object.theName.ToLower();

            return @object;
        }
    }

    public class MyClassBuilder
    {
        private string _aNameToSet;
        private bool _prependPropertyDescriptor = false;
        private bool _lowerizeOutput = false;

        public MyClassBuilder SetTheName(string aNameToSet)
        {
            _aNameToSet = aNameToSet;
            return this;
        }
        
        public MyClassBuilder PrependPropertyDescriptor()
        {
            _prependPropertyDescriptor = true;
            return this;
        }

        public MyClassBuilder LowerizeOutput()
        {
            _lowerizeOutput = true;
            return this;
        }

        public MyClass Build()
        {
            return new MyClass(_aNameToSet, _prependPropertyDescriptor, _lowerizeOutput);
        }
    }

    public class MyClassClient
    {
        public void ExecuteTheDefaultUseCase()
        {
            var myClass = new MyClassBuilder()
                .SetTheName("the first use case is simple")
                .Build();

            var theResult = myClass.DoSomeBehavior();
        }

        public void ExecuteAnotherUseCase()
        {
            var myClass = new MyClassBuilder()
                .SetTheName("the first another one")
                .PrependPropertyDescriptor()
                .LowerizeOutput()
                .Build();

            var theResult = myClass.DoSomeBehavior();
        }
    }
    
}