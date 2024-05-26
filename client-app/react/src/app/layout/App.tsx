import { Outlet, useLocation } from "react-router-dom";
import AppFooter from "./footer/Footer";
import { useStore } from "../store/store";
import { useEffect } from "react";
import LoadingApp from "./LoadingApp";
import { observer } from "mobx-react-lite";
import AppNavBar from "./navbar/Navbar";

function App() {
  const { appCompanyStore } = useStore();

  useEffect(() => {
    appCompanyStore.getCompanyDetail().then(() => {
      appCompanyStore.setCompanyLoaded();
    });
  }, [appCompanyStore]);

  if (!appCompanyStore.companyLoaded) return <LoadingApp />;

  const location = useLocation();

  return (
    <div className="min-h-[100vh] relative">
      {location.pathname.startsWith("/auth/") ||
      location.pathname.startsWith("/test") ? null : (
        <AppNavBar />
      )}
      <div className="max-w-[1280px] min-w-[375px] mx-auto">
        <Outlet />
      </div>
      <div className="absolute bottom-0 w-full">
        {location.pathname.startsWith("/test") ? null : <AppFooter />}
      </div>
    </div>
  );
}

export default observer(App);
