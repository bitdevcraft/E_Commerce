import { motion } from "framer-motion";

function LoadingApp() {
  return (
    <div className="w-[100vw] h-[100vh] flex justify-center items-center bg-blue-200">
      <motion.div
        className="box bg-white w-32 h-32"
        animate={{
          scale: [1, 2, 2, 1, 1],
          rotate: [0, 0, 180, 180, 0],
          borderRadius: ["0%", "0%", "50%", "50%", "0%"],
        }}
        transition={{
          duration: 2,
          ease: "easeInOut",
          times: [0, 0.2, 0.5, 0.8, 1],
          repeat: Infinity,
          repeatDelay: 1,
        }}
      />
    </div>
  );
}

export default LoadingApp;
