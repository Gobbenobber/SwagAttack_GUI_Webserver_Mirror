﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using Domain.Models;
using GUICommLayer.Interfaces;
using GUI_Index.Controllers;
using GUI_Index.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
//https://dotnetliberty.com/index.php/2016/01/04/how-to-unit-test-asp-net-5-mvc-6-modelstate/


namespace WebserverUnitTests
{
	[TestFixture]
	class KontoControllerUnitTest
    {
	    private readonly IUserProxy _fakeUserProxy = Substitute.For<IUserProxy>();
	    private RegistorViewModel RVM;

	    private KontoController _uut;

	    [SetUp]
	    public void Init()
	    {
			_uut = new KontoController(_fakeUserProxy);

			RVM = new RegistorViewModel()
		    {
			    Username = "TestTango200",
			    Email = "test@tango.dk",
			    GivenName = "test",
			    LastName = "tango",
			    Password = "tangoPassword",
			    ConfirmPassword = "tangoPassword"

		    };
		}

	    [Test]
	    public void OpretKonto()
	    {
			var result = _uut.OpretKonto() as ViewResult;

		    Assert.AreEqual("OpretKonto", result);
		}

	    [Test]
	    public void OpretKonto_With_Correct_RVM_call_proxy_Right_Email()
	    {
			//Arrange

			User savedUser = null;
		    _fakeUserProxy.CreateInstanceAsync(Arg.Do<User>(x => savedUser = x));

			//Ack
			_uut.OpretKonto(RVM);
		    //Assert
		    
		    Assert.That(savedUser.Email, Is.EqualTo(RVM.Email));
	    }
	    [Test]
	    public void OpretKonto_With_Correct_RVM_call_proxy_Right_GivenName()
	    {
		    //Arrange

		    User savedUser = null;
		    _fakeUserProxy.CreateInstanceAsync(Arg.Do<User>(x => savedUser = x));

		    //Ack
		    _uut.OpretKonto(RVM);
		    //Assert

		    Assert.That(savedUser.GivenName, Is.EqualTo(RVM.GivenName));
	    }

	    [Test]
	    public void OpretKonto_With_Correct_RVM_call_proxy_Right_LastName()
	    {
		    //Arrange

		    User savedUser = null;
		    _fakeUserProxy.CreateInstanceAsync(Arg.Do<User>(x => savedUser = x));

		    //Ack
		    _uut.OpretKonto(RVM);
		    //Assert

		    Assert.That(savedUser.LastName, Is.EqualTo(RVM.LastName));
	    }

	    [Test]
	    public void OpretKonto_With_Correct_RVM_call_proxy_Right_Username()
	    {
		    //Arrange

		    User savedUser = null;
		    _fakeUserProxy.CreateInstanceAsync(Arg.Do<User>(x => savedUser = x));

		    //Ack
		    _uut.OpretKonto(RVM);
		    //Assert

		    Assert.That(savedUser.Username, Is.EqualTo(RVM.Username));
	    }
	    [Test]
	    public void OpretKonto_With_Correct_RVM_call_proxy_Right_Password()
	    {
		    //Arrange

		    User savedUser = null;
		    _fakeUserProxy.CreateInstanceAsync(Arg.Do<User>(x => savedUser = x));

		    //Ack
		    _uut.OpretKonto(RVM);
		    //Assert

		    Assert.That(savedUser.Password, Is.EqualTo(RVM.Password));
	    }



	}
}
