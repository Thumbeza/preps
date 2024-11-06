using FluentAssertions;
using Invstec.Assessment.PageObjects;

namespace Invstec.Assessment.Tests;

public class SubsribptionTests : IClassFixture<BaseFixture>
{
    private readonly BaseFixture _fixture;
    public SubsribptionTests(BaseFixture fixture) 
    {
        _fixture = fixture;
    }

    [Fact]
    public void GivenUserDetails_SubscribeToFocusInsights() 
    {
        var landingPage = new LandingPage(_fixture.Driver);

        landingPage.IsPageVisible.Should().BeTrue();
        landingPage.OpenSignUpInformationPage();

        var signUpInformationPage = new SignUpInformationPage(_fixture.Driver);

        signUpInformationPage.IsPageVisible.Should().BeTrue();
        signUpInformationPage.AddName("Nomusa");
        signUpInformationPage.AddSurname("Mdlalose");
        signUpInformationPage.AddEmail("nomusa@foo.com");
        signUpInformationPage.SelectService(Service.Insurance);

        signUpInformationPage.IsSubmitButtonClickable().Should().BeFalse();
        signUpInformationPage.AddYearOfBirth(1992);

        signUpInformationPage.Sumbit();
    }
}

public static class Service
{
    public static string Savings => "Savings";
    public static string Insurance => "Insurance";
}
