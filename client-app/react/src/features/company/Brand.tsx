import { Flex } from "antd";
import Logo from "./Logo";
import { useStore } from "../../app/store/store";

function Brand() {
  const { appCompanyStore } = useStore();
  return (
    <Flex align="center" gap={10} className="">
      <Logo className="w-[60px]" />
      <p className="font-bold text-3xl">
        {appCompanyStore.company?.name ?? "Default Company"}
      </p>
    </Flex>
  );
}

export default Brand;
