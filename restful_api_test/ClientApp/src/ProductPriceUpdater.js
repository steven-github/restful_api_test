import React, { useState } from "react";
import axios from "axios";

const ProductPriceUpdater = () => {
  const [productId, setProductId] = useState("");
  const [newPrice, setNewPrice] = useState("");
  const [message, setMessage] = useState("");

  const handleUpdatePrice = async () => {
    try {
      const response1 = await axios.get(`/api`);
      console.log(response1);
      const response = await axios.put(
        `https://localhost:7011/api/Products/${newPrice}`,
        {
          newPrice: parseFloat(newPrice),
        }
      );
      console.log(response);
      setMessage(response.data);
    } catch (error) {
      setMessage(error.response.data);
    }
  };

  return (
    <div>
      <h2>Update Product Price</h2>
      <input
        type="text"
        placeholder="Product ID"
        value={productId}
        onChange={(e) => setProductId(e.target.value)}
      />
      <input
        type="text"
        placeholder="New Price"
        value={newPrice}
        onChange={(e) => setNewPrice(e.target.value)}
      />
      <button onClick={handleUpdatePrice}>Update Price</button>
      {message && <p>{message}</p>}
    </div>
  );
};

export default ProductPriceUpdater;
