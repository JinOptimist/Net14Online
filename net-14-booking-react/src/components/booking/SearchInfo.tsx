import {useParams} from "react-router-dom"

function SearchInfo (){
    const {id} = useParams();
return(<div>
 Here is info about the search {id}
</div>
);
}
export default SearchInfo;