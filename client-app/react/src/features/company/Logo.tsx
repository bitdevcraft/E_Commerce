import { observer } from "mobx-react-lite";
import { useStore } from "../../app/store/store";

interface Props {
  className?: string;
}

function Logo(props: Props) {
  const { appCompanyStore } = useStore();
  const logo = (appCompanyStore.company?.logo ?? "").replace(" ", "%20");
  return (
    <>
      {logo ? (
        <img
          src={`${import.meta.env.VITE_DEFAULT_URL}${logo}`}
          alt=""
          {...props}
        />
      ) : (
        <img src={`/public/assets/react.svg`} alt="" />
      )}
    </>
  );
}

export default observer(Logo);
