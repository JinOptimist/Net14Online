import { ChangeEvent, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import IHero from "../../../models/IHero";
import dndApi from "../../../services/dndApi";
import './hero-profile.css'

function HeroProfile() {
	const { id } = useParams<string>()
	const [HeroProfile, setHeroProfile] = useState<IHero>()
	const { getHeroProfile, uploadAvatar } = dndApi
	const [NewAvatarFile, setNewAvatarFile] = useState<File>({} as File);

	useEffect(() => {
		getHeroProfile(id ?? "")
			.then(({ data }) => {
				setHeroProfile(data as IHero)
			})
	}, [])

	function onAvatarFileChange(event: ChangeEvent<HTMLInputElement>): void {
		const data = event.target.files?.[0];
		if (data) {
			setNewAvatarFile(data)
		}
	}

	function updateAvatar(): void {
		uploadAvatar(id ?? "", NewAvatarFile)
			.then(({ data }) => {
				setHeroProfile(oldData => {
					return { ...oldData, avatarUrl: data } as IHero
				})
			});
	}

	return (
		<div>
			Герой {HeroProfile?.name} [{HeroProfile?.id}]
			<div className="avatar-container">
				<img src={dndApi.SERVER_URL + HeroProfile?.avatarUrl} alt="" />
			</div>
			<div>
				<input type="file" onChange={onAvatarFileChange} />
				<button onClick={updateAvatar}>Update avatar</button>
			</div>

		</div>);
}

export default HeroProfile;