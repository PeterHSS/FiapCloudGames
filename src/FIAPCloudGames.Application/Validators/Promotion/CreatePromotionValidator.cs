﻿using FIAPCloudGames.Application.DTOs.Promotion;

namespace FIAPCloudGames.Application.Validators.Promotion;

public sealed class CreatePromotionValidator : AbstractPromotionValidator<CreatePromotionRequest>
{
    public CreatePromotionValidator()
    {
        AddNameRule(request => request.Name);

        AddStartDateRule(request => request.StartDate);

        AddEndDateRule(request => request.EndDate, request => request.StartDate);

        AddDiscountPercentageRule(request => request.DiscountPercentage);

        AddDescriptionRule(request => request.Description);
    }
}
