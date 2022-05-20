using Microsoft.EntityFrameworkCore;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject.Specs.Steps
{
    [Binding]
    public sealed class ChargingPointDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private ChargingPointIntentModel _chargingPointModel;
        private DbContext _dbContext;
        private RepositoryFacade _repositoryFacade;
        private ChargingPointManager _chargingPointManager;
        private ChargingPointController _chargingPointController;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _chargingPointModel = new ChargingPointIntentModel();
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            _dbContext.Database.EnsureDeleted();
            _repositoryFacade = new RepositoryFacade(_dbContext);
            _chargingPointManager = new ChargingPointManager(_repositoryFacade);
            _chargingPointController = new ChargingPointController(_chargingPointManager);
        }
        public ChargingPointDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given("the identificator is (.*)")]
        public void GivenTheIdIs(int identificator)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            //_scenarioContext.Pending();
            _chargingPointModel.Identificator = identificator;
        }

        [Given("the name is (.*)")]
        public void GivenTheNameIs(string name)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _chargingPointModel.Name = name;
        }

        [Given("the address is (.*)")]
        public void GivenTheAddressIs(string address)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _chargingPointModel.Address = address;
        }
        [Given("the region is (.*)")]
        public void GivenTheRegionIs(int regionId)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 
            _dbContext.Set<Region>().Add(new Region() { Id = 1, Name = "Centro Oeste" });
            _dbContext.SaveChanges();
            _chargingPointModel.RegionId = regionId;
        }
        [Given("the description is (.*)")]
        public void GivenTheDescriptionIs(string description)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _chargingPointModel.Description = description;
        }

        [Given(@"the correct identificator is (.*)")]
        public void GivenTheCorrectIdentificatorIs(int identificator)
        {
            _chargingPointModel.Identificator = identificator;
            _dbContext.Set<Region>().Add(new Region() { Id = 1, Name = "Centro Oeste" });
            _chargingPointModel.RegionId = 1;
            _chargingPointModel.Name = "ExampleName";
            _chargingPointModel.Address = "ExampleAddress";
            _chargingPointModel.Description = "ExampleDescription";
            _dbContext.SaveChanges();
            _repositoryFacade.StoreChargingPoint(_chargingPointModel.ToEntity());
        }

        [Given(@"the incorrect identificator is (.*)")]
        public void GivenTheIncorrectIdentificatorIs(int p0)
        {
           //Nothing to do.
        }

        [When(@"the create button is pressed")]
        public void WhenTheCreateButtonIsPressed()
        {
            try
            {
                Assert.NotNull(_chargingPointController.CreateChargingPoint(_chargingPointModel));
               
            }
            catch (Exception e)
            {
                _scenarioContext.Add("CreateChargingPointException", e);
            }
        }

        [When(@"the delete button is pressed")]
        public void WhenTheDeleteButtonIsPressed()
        {
            try
            {
               
                _chargingPointController.DeleteChargingPoint(_chargingPointModel.Identificator);
            }
            catch (Exception e)
            {
                _scenarioContext.Add("DeleteChargingPointException", e);
            }
        }

        [Then(@"the result should be Point of charge added")]
        public void ThenTheResultShouldBePointOfChargeAdded()
        {
            Assert.NotNull(_repositoryFacade.GetChargingPointByIdentificator(_chargingPointModel.Identificator));
        }
        
        [Then(@"the result should be Charging point identificator must be (.*) digits")]
        public void ThenTheResultShouldBeChargingPointIdentificatorMustBeDigits(int p0)
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Charging point identificator must be 4 digits", exception.Message);
        }

        [Then(@"the result should be Charging point name must be less than (.*) letters and contain only alphabetical characters")]
        public void ThenTheResultShouldBeChargingPointNameMustBeLessThanLettersAndContainOnlyAlphabeticalCharacters(int p0)
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Charging point name must be less than 20 letters and contain only alphabetical characters", exception.Message);
        }

        [Then(@"the result should be Charging point description must be less than (.*) letters")]
        public void ThenTheResultShouldBeChargingPointDescriptionMustBeLessThanLetters(int p0)
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Charging point description must be less than 60 letters", exception.Message);
        }

        [Then(@"the result should be Charging point address must be less than (.*) letters and contain only alphabetical characters")]
        public void ThenTheResultShouldBeChargingPointAddressMustBeLessThanLettersAndContainOnlyAlphabeticalCharacters(int p0)
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Charging point address must be less than 30 letters and contain only alphabetical characters", exception.Message);
        }

        [Then(@"the result should be Could not find specified region")]
        public void ThenTheResultShouldBeCouldNotFindSpecifiedRegion()
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(ResourceNotFoundException), exception.GetType());
            Assert.Equal("Could not find specified region", exception.Message);
        }

        [Then(@"the result should be All charging point fields are mandatory")]
        public void ThenTheResultShouldBeAllChargingPointFieldsAreMandatory()
        {
            Exception exception = (Exception)_scenarioContext["CreateChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("All charging point fields are mandatory", exception.Message);
        }

        [Then(@"the result should be charging point deleted")]
        public void ThenTheResultShouldBeChargingPointDeleted()
        {
            Assert.Null(_dbContext.Set<ChargingPoint>().Where(cp => cp.Identificator == _chargingPointModel.Identificator).FirstOrDefault());
        }

        [Then(@"the result should be Inexistent charging point")]
        public void ThenTheResultShouldBeInexistentChargingPoint()
        {
            Exception exception = (Exception)_scenarioContext["DeleteChargingPointException"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(ResourceNotFoundException), exception.GetType());
            Assert.Equal("Could not find specified charging point", exception.Message);
        }
    }
}
