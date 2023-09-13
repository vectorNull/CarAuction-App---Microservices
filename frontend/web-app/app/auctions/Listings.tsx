'use client'

import React, { useEffect, useState } from "react";
import AuctionCard from "./AuctionCard";
import AppPagination from "../components/AppPagination";
import { Auction } from "@/types";
import { getData } from "../actions/auctionActions"
import Filters from "./Filters";

// when using client-side component with a server-side actions 
// (see actions folder), remove async or it will hang
export default function Listings() {
	const [auctions, setAuctions] = useState<Auction[]>([]);
	const [pageCount, setPageCount] = useState(0);
	const [pageNumber, setPageNumber] = useState(1);
	const [pageSize, setPageSize] = useState(4);

	useEffect(() => {
		getData(pageNumber, pageSize).then(data => {
			setAuctions(data.results);
			setPageCount(data.pageCount);
		})
	}, [pageNumber, pageSize])

	if (auctions.length === 0) return <h3>Loading...</h3>
	
	return (
		<>
			<Filters pageSize={pageSize} setPageSize={setPageSize}/>
			<div className="grid grid-cols-4 gap-6">
				{auctions && auctions.map((auction) => (
					<AuctionCard auction={auction} key={auction.id} />
				))}
			</div>
			<div className="flex justify-center mt-4">
					<AppPagination pageChanged={setPageNumber} currentPage={pageNumber} pageCount={pageCount}/>
			</div>
		</>
	)
}
