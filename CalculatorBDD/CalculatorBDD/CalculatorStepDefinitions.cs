using CalculatorLib;
using System;
using TechTalk.SpecFlow;

namespace CalculatorBDD
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private Calculator _calculator;
        private int _result;

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculator = new Calculator();
        }

        [Given(@"I enter (.*) and (.*) into the calculator")]
        public void GivenIEnterAndIntoTheCalculator(int p0, int p1)
        {
            _calculator.Num1 = p0;
            _calculator.Num2 = p1;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }

        [When(@"I press subtract")]
        public void WhenIPressSubtract()
        {
            _result = _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _result = _calculator.Multiply();
        }

        //[When(@"I press divide")]
        //public void WhenIPressDivide()
        //{
        //    _result = _calculator.Divide();
        //}

        [When("I press divide")]
        public void WhenIPressDivide()
        {
            try
            {
                _result = _calculator.Divide();
            }
            catch (Exception err)
            {
                ScenarioContext.Current[("Error")] = err;
            }
        }

        //[Then(@"then divide by 0 exception is thrown")]
        //public void thendivideby0exceptionisthrown()
        //{
        //    Assert.That(() => _calculator.Divide(), Throws.TypeOf<DivideByZeroException>());
        //}

        [Then(@"it should throw an exception")]
        public void ThenItShouldThrowAnException()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Error"));
        }







        [Given(@"I enter the numbers below to a list")]
        public void GivenIEnterTheNumbersBelowToAList(Table table)
        {
            List<int> numbers = new List<int>();
            foreach (var row in table.Rows)
            {
                numbers.Add((Convert.ToInt32(row[0])));
            }
            _calculator.Numbers = numbers;
        }

        [When(@"I iterate through the list to add all the even numbers")]
        public void WhenIIterateThroughTheListToAddAllTheEvenNumbers()
        {
            _result = _calculator.Sum();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expected)
        {
            Assert.That(_result, Is.EqualTo(expected));
        }

    }
}