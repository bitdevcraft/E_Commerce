import { Button, Result } from "antd";

function InternalError() {
  return (
    <div className="h-[100vh] justify-center flex items-center">
      <Result
        status="500"
        title="500"
        subTitle="Sorry, something went wrong."
        extra={<Button href="/">Back Home</Button>}
      />
    </div>
  );
}

export default InternalError;
