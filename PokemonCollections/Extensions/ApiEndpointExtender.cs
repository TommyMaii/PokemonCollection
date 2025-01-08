// using Microsoft.AspNetCore.Authentication.BearerToken;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.AspNetCore.Http.Metadata;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Options;
// using PokemonCollections.Models;
//
// namespace PokemonCollections.Extensions;
//
// public class ApiEndpointExtender
// {
//     public static IEndpointConventionBuilder CustomMapIdentityApi<TUser>(IEndpointRouteBuilder endpoints)
//         where TUser : PokemonUser, new()
//     {
//         ArgumentNullException.ThrowIfNull(endpoints);
//
//         var timeProvider = endpoints.ServiceProvider.GetRequiredService<TimeProvider>();
//         var bearerTokenOptions = endpoints.ServiceProvider.GetRequiredService<IOptionsMonitor<BearerTokenOptions>>();
//         var linkGenerator = endpoints.ServiceProvider.GetRequiredService<LinkGenerator>();
//
//         // We'll figure out a unique endpoint name based on the final route pattern during endpoint generation.
//         string? confirmEmailEndpointName = null;
//
//         var routeGroup = endpoints.MapGroup("");
//
//         routeGroup.MapPost("/login", async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>>
//         ([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies,
//             [FromServices] IServiceProvider sp) =>
//         {
//             var signInManager = sp.GetRequiredService<SignInManager<TUser>>();
//
//             var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
//             var isPersistent = (useCookies == true) && (useSessionCookies != true);
//             signInManager.AuthenticationScheme =
//                 useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;
//
//             var result =
//                 await signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent,
//                     lockoutOnFailure: true);
//
//             if (result.RequiresTwoFactor)
//             {
//                 if (!string.IsNullOrEmpty(login.TwoFactorCode))
//                 {
//                     result = await signInManager.TwoFactorAuthenticatorSignInAsync(login.TwoFactorCode, isPersistent,
//                         rememberClient: isPersistent);
//                 }
//                 else if (!string.IsNullOrEmpty(login.TwoFactorRecoveryCode))
//                 {
//                     result = await signInManager.TwoFactorRecoveryCodeSignInAsync(login.TwoFactorRecoveryCode);
//                 }
//             }
//
//             if (!result.Succeeded)
//             {
//                 return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
//             }
//
//             // The signInManager already produced the needed response in the form of a cookie or bearer token.
//             return TypedResults.Empty;
//         });
//         return new IdentityEndpointsConventionBuilder(routeGroup);
//     }
//     
//     private sealed class IdentityEndpointsConventionBuilder(RouteGroupBuilder inner) : IEndpointConventionBuilder
//     {
//         private IEndpointConventionBuilder InnerAsConventionBuilder => inner;
//
//         public void Add(Action<EndpointBuilder> convention) => InnerAsConventionBuilder.Add(convention);
//         public void Finally(Action<EndpointBuilder> finallyConvention) => InnerAsConventionBuilder.Finally(finallyConvention);
//     }
//
//     [AttributeUsage(AttributeTargets.Parameter)]
//     private sealed class FromBodyAttribute : Attribute, IFromBodyMetadata
//     {
//     }
//
//     [AttributeUsage(AttributeTargets.Parameter)]
//     private sealed class FromServicesAttribute : Attribute, IFromServiceMetadata
//     {
//     }
//
//     [AttributeUsage(AttributeTargets.Parameter)]
//     private sealed class FromQueryAttribute : Attribute, IFromQueryMetadata
//     {
//         public string? Name => null;
//     }
// }