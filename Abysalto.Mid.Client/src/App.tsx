import { useAxiosInterceptor } from "./hooks/useAxiosInterceptor";
import Navbar from "./components/Navbar";

function App() {
  useAxiosInterceptor();

  // const callProducts = () => {
  //   axios.get("http://localhost:5269/api/product").then((data) => {
  //     console.log(data);
  //   });
  // };

  return (
    <div>
      <Navbar />
    </div>
  );
}

export default App;
