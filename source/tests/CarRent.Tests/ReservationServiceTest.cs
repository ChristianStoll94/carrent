using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRent.CarManagement.Application;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.API;
using CarRent.CustomerManagement.Domain;
using CarRent.Models.DBModels;
using CarRent.ReservationManagement.Application;
using CarRent.ReservationManagement.Domain;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;
using Times = Moq.Times;

namespace CarRent.Tests
{
    class ReservationServiceTest
    {
        [Test]
        public void CalculatePrice_CalculateReservationPrice_GetExpectedResult()
        {
            //Arrange
            var reservationRepository = new Mock<IReservationRepository>();
            reservationRepository.Setup(p => p.GetPrice(1)).Returns(3);
            var reservationService = new ReservationService(reservationRepository.Object);

            //Act
            var result = reservationService.CalculatePrice(1, 4);

            //Assert
            result.Should().Be(12);
        }

        [Test]
        public void CreateReservation_AddReservation_isCalled()
        {
            //Arrange
            var reservation = A.Fake<Reservation>();
            var reservationRepository = new Mock<IReservationRepository>();
            reservationRepository.Setup(p => p.Get(1)).Returns(reservation);
            var reservationService = new ReservationService(reservationRepository.Object);

            //Act
            try
            {
                var result = reservationService.GetReservation(1);
            }
            catch (Exception e)
            { }

            //Assert
            reservationRepository.Verify(o => o.Get(1), Times.Once);
        }


    }
}
