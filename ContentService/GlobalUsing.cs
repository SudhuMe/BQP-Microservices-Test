﻿global using ContentService.CQRS.Commands.CreateBooking;
global using ContentService.CQRS.Commands.CreateBooking.Request;
global using ContentService.CQRS.Queries.GetBooking;
global using MassTransit;
global using MediatR;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Service.Shared;
global using ContentService.CQRS.Queries.GetBookings;
global using AutoMapper;
global using Abstraction.Result;
global using FluentValidation;
