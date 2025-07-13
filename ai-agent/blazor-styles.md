The web app is using MudBlazor for components and styling, so take into account the styles and CSS classes defined by MudBlazor

When modifying css styles take into account that Blazor uses CSS isolation on its' components, we need to set the styles in the corresponding razor.css file.
Reference Blazor CSS isolation: https://learn.microsoft.com/en-us/aspnet/core/blazor/components/css-isolation