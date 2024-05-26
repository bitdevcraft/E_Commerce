import { Outlet } from "react-router-dom";

function Main() {
  return (
    <>
      <p className="w-full text-center">Admin Panel</p>
      <Outlet />
    </>
  );
}

export default Main;
