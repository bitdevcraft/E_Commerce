import { Flex } from "antd";
import { Brand } from "../company";
import { Outlet } from "react-router-dom";

function AuthMain() {
  return (
    <>
      <Flex justify="center" className="pt-12 md:pt-32">
        <Brand />
      </Flex>
      <Flex justify="center" align="center" className="w-full mt-24 md:mt-4">
        <Outlet />
      </Flex>
    </>
  );
}

export default AuthMain;
