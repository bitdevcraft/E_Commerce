import { Footer } from "antd/es/layout/layout";
import { useStore } from "../../store/store";

function DefaultFooter() {
  const { appCompanyStore } = useStore();
  return (
    <Footer className="text-center bg-inherit w-full flex justify-center">
      <div className=" w-full pt-2 max-w-[400px]">
        <p className="font-semibold">
          {appCompanyStore.company?.name} ©{new Date().getFullYear()}
        </p>
        <p className="text-xs">Created by {appCompanyStore.company?.name}</p>
      </div>
    </Footer>
  );
}

export default DefaultFooter;
