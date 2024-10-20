﻿namespace Restaurants.Infrastructure.Authorization;

public static class PolicyNames
{
    public const string HasNationality = "HasNationality";
    public const string AtLeast20 = "AtLeast20";
    public const string MoreThan1Restaurant = "MoreThan1Restaurant";
}

public static class AppClaimTypes
{
    public const string Nationality = "Nationality";
    public const string DateOfBirth = "DateOfBirth";
    public const int MinimumAge = 20;
    public const int MinimumOwnedRestaurants = 2;
}