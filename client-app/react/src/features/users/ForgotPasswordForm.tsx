import { Button, Flex } from "antd";
import { Form, Formik } from "formik";
import { AiOutlineUser } from "react-icons/ai";

import * as yup from "yup";
import { MyTextInput } from "../../app/common/form";

const schema = yup
  .object({
    email: yup
      .string()
      .required()
      .matches(/^[\w-\\.]+@([\w-]+\.)+[\w-]{2,4}$/, "Invalid Email"),
  })
  .required();

function ForgotPasswordForm() {
  const initialValues = {
    email: "",
    error: null,
  };
  return (
    <Formik
      initialValues={initialValues}
      onSubmit={(values: any) => {
        console.log(values);
      }}
      enableReinitialize
      validationSchema={schema}
    >
      {({ handleSubmit, isSubmitting }) => (
        <Form
          onSubmit={handleSubmit}
          className="space-y-3 max-w-[600px] w-full px-8 md:p-12"
        >
          <div>
            <p className="text-xl font-bold text-gray-900">Can't log in?</p>
          </div>
          <div className="space-y-1">
            <p className="text-xs font-semibold text-gray-500">
              We'll send a recovery link to
            </p>
            <div>
              <MyTextInput
                prefix={<AiOutlineUser size={20} />}
                name="email"
                placeholder="Enter Email"
              />
            </div>
          </div>
          <Button
            type="primary"
            className="w-full border bg-blue-400"
            htmlType="submit"
            loading={isSubmitting}
          >
            Send recovery link
          </Button>
          <Flex justify="center">
            <Button type="link" className="text-blue-400" href="/auth/login">
              Return to log in
            </Button>
          </Flex>
        </Form>
      )}
    </Formik>
  );
}

export default ForgotPasswordForm;
