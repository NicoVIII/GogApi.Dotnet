module GogApi.DotNet.FSharp.Listing

type FilteredProductsRequest = {
    search :string
}

type ProductInfo = {
    id: int;
    title: string;
}

type FilteredProductsResponse = {
    totalProducts: int;
    products: ProductInfo list;
}

let askForFilteredProducts auth (request :FilteredProductsRequest) =
    let queries = [
        createQuery "mediaType" "1";
        createQuery "search" request.search
    ]
    makeRequest<FilteredProductsResponse> auth queries "https://embed.gog.com/account/getFilteredProducts"
