import { Button, Result } from "antd";

function NotAuthorized() {
  return (
    <div className="h-[100vh] justify-center flex items-center">
      <Result
        status="403"
        title="403"
        subTitle="Sorry, you are not authorized to access this page."
        extra={<Button href="/">Back Home</Button>}
      />
    </div>
  );
}

export default NotAuthorized;
