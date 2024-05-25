import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";

//  Features
import * as Features from "../../features";

// Errors
import * as Errors from "../../features/error";

// Admin
import * as Admin from "../../features/admin";
import ContentBody from "../layout/content/Content";

export const routes: RouteObject[] = [
  {
    path: "/",
    element: <App />,
    children: [
      // For Development
      { path: "test", element: <ContentBody /> },

      // For Normal Use-Case
      /** User */
      {
        path: "auth/",
        element: <Features.User.AuthMain />,
        children: [
          { path: "login", element: <Features.User.LoginForm /> },
          { path: "register", element: <Features.User.RegisterForm /> },
          {
            path: "forgot-password",
            element: <Features.User.ForgotPasswordForm />,
          },
        ],
      },

      // Error

      { path: "*", element: <Errors.PageNotFound /> },
      { path: "not-authorized", element: <Errors.NotAuthorized /> },
      { path: "internal-error", element: <Errors.InternalError /> },

      // Admin
      // - Company Profile

      {
        path: "admin/",
        element: <Admin.Main />,
        children: [
          { path: "companyprofile", element: <Admin.CompanyProfileView /> },
          {
            path: "companyprofile-edit",
            element: <Admin.CompanyProfileEdit />,
          },
        ],
      },
    ],
  },
];

export const router = createBrowserRouter(routes);
