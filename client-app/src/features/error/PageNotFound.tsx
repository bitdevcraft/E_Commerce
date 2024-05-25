import { Button, Result } from "antd";

function PageNotFound() {
  return (
    <div className="h-[100vh] justify-center flex items-center">
      <Result
        status="404"
        title="404"
        subTitle="Sorry, the page you visited does not exist."
        extra={<Button href="/">Back Home</Button>}
      />
    </div>
  );
}

export default PageNotFound;
