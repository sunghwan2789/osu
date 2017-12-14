// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;

namespace osu.Game.Screens.Select.Carousel
{
    /// <summary>
    /// A group which ensures at least one child is selected (if the group itself is selected).
    /// </summary>
    public class CarouselGroupEagerSelect : CarouselGroup
    {
        public CarouselGroupEagerSelect()
        {
            State.ValueChanged += v =>
            {
                if (v == CarouselItemState.Selected)
                {
                    foreach (var c in InternalChildren.Where(c => c.State.Value == CarouselItemState.Hidden))
                        c.State.Value = CarouselItemState.NotSelected;

                    if (InternalChildren.Any(c => c.Visible) && InternalChildren.All(c => c.State != CarouselItemState.Selected))
                        InternalChildren.First(c => c.Visible).State.Value = CarouselItemState.Selected;
                }
            };
        }
    }
}
