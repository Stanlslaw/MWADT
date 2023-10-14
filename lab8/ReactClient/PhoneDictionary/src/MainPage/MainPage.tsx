import axios from "axios";
import { useState, useEffect } from 'react';

interface PhoneRaw {
    id: number;
    name: string;
    phoneNumber: string;
}

export default function MainPage() {
    const [products, setProducts] = useState<PhoneRaw[]>([]);

    useEffect(() => {
        async function fetchProducts() {
            try {
                const response = await axios.get<PhoneRaw[]>("https://localhost:44380/api/phonebookcontroller/getallrecords");
                setProducts(response.data);
            } catch (error) {
                console.error('Error fetching products:', error);
            }
        }

        fetchProducts();
    }, []);

    return (
        <div>
            {/* Render the products */}
            {products.map((product) => (
                <div key={product.id}>
                    <p>{product.id} {product.name} {product.phoneNumber}</p>
                </div>
            ))}
        </div>
    );
}