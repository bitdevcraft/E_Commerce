import { createContext, useContext } from "react";
import AppCompanyStore from "./appCompany";
import CommonStore from "./commonStore";
import UserStore from "./userStore";
import ModalStore from "./modalStore";

interface Store {
  appCompanyStore: AppCompanyStore;
  commonStore: CommonStore;
  userStore: UserStore;
  modalStore: ModalStore;
}
export const store: Store = {
  appCompanyStore: new AppCompanyStore(),
  commonStore: new CommonStore(),
  userStore: new UserStore(),
  modalStore: new ModalStore(),
};
export const StoreContext = createContext(store);
export function useStore() {
  return useContext(StoreContext);
}
